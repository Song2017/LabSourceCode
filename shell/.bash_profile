# python virtual envs
export WORKON_HOME="~/.virtualenvs"
# export VIRTUALENVWRAPPER_PYTHON='/usr/local/Cellar/python/3.7.5/bin/python3'
# source /usr/local/bin/virtualenvwrapper.sh  # virtualenvwrapper.sh的路径

alias ll="ls -al"
# alias chrome="/Applications/Google\ Chrome.app/Contents/MacOS/Google\ Chrome"
alias python="/usr/local/bin/python3"
# alias python37="/usr/local/Cellar/python/3.7.5/bin/python3.7"
# alias python2="/System/Library/Frameworks/Python.framework/Versions/2.7/bin/python2.7"
alias pip="/usr/local/bin/pip3"

# Setting PATH for Python 3.6
# The original version is saved in .bash_profile.pysave
PATH="/Library/Frameworks/Python.framework/Versions/3.6/bin:${PATH}"
export PATH

# Git
alias gst="git status"
alias ga="git add ."
alias gcm="git commit -m "

alias gb="git branch"
alias gba="git branch -a"
alias gbd="git branch -d"

alias gp="git pull"
alias gpo="git pull origin"
alias gpom="git pull origin master"

alias grh="git reset --hard"
alias grs="git reset --soft head^"
alias gdh="git diff head"
alias gl="git log"

alias gkt="git checkout"
alias gktm="git checkout master"

alias gfp="git fetch --prune"

# docker
alias dis="docker images"
alias dps="docker ps -a"
alias dsp="docker system prune -f"
alias drm="docker rm -f"
alias drmi="docker rmi -f"

# redis
export redis_path="/Applications/Redis.app/Contents/Resources/Vendor/redis"
alias redis-cli="/Applications/Redis.app/Contents/Resources/Vendor/redis/bin/redis-cli"
alias redis-server="/Applications/Redis.app/Contents/Resources/Vendor/redis/bin/redis-server"
export PATH="/usr/local/opt/openjdk/bin:$PATH"
export PATH="/usr/local/opt/openssl@1.1/bin:$PATH"

# Vault
export VAULT_ADDR="https://v.samarkand-global.cn"
complete -C /usr/local/bin/bitcomplete bit
export PATH="/usr/local/opt/icu4c/bin:$PATH"
export PATH="/usr/local/opt/icu4c/sbin:$PATH"

# pongo
export PATH="~/.local/bin:$PATH"

# go
export GOROOT=/usr/local/Cellar/go/1.15.5/libexec
export GOPATH=$HOME/go
# export GOPATH=$HOME/go-workspace # don't forget to change your path correctly!
# export GOROOT=/usr/local/opt/go/libexec
export PATH=$PATH:$GOPATH/bin
export PATH=$PATH:$GOROOT/bin