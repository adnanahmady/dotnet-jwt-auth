define default
$(if $(1), $(1), $(2))
endef

define prefix
$(if $(1), $(2)=$(1),)
endef

setup:
	@mkdir -p .backend/home/.nuget
	@mkdir -p .backend/home/.aspnet/https
	$(MAKE) up
	$(MAKE) shell run="sudo chmod -R 777 /home/docker/.nuget"
	$(MAKE) shell run="sudo chmod -R 777 /home/docker/.aspnet"
	$(MAKE) shell run="dotnet restore"
	$(MAKE) shell run="dotnet tool restore"
	$(MAKE) shell run="dotnet dev-certs https --trust --export-path /home/docker/.aspnet/https/auth.pfx"


up:
	@docker compose up -d ${up-with}

down:
	@docker compose down ${down-with}

build:
	@docker compose build ${build-with}

restart:
	@docker compose restart ${restart-with}

logs:
	@docker compose logs ${log-with}

shell:
	@docker compose exec $(call default,${service},backend) $(call default,${run},bash)

ps:
	@docker compose ps
status: ps

run:
	$(MAKE) shell run="dotnet run --project src/JwtAuth.Api/"

test:
	$(MAKE) shell run="dotnet test $(call default,$(call prefix,${filter},--filter=),$(call prefix,${f},--filter=)) ${with}"

restore:
	$(MAKE) shell run="dotnet restore"

restore-tools:
	$(MAKE) shell run="dotnet tool restore"

fix:
	$(MAKE) shell run="dotnet format style"
	$(MAKE) shell run="dotnet format style --severity=info"
	$(MAKE) shell run="dotnet format whitespace"
